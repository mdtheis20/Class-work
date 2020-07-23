<template>
  <div class="main">
    <img alt="Cigar party!" src="../assets/cigarparty.jpg" />

    <!-- Everything needs to be inside this root element -->
    <h2>Product Reviews for {{title}}</h2>
    <p class="description">{{description}}</p>

    <div class="well-display">
      <!-- Set the filter when the user clicks on the display -->
      <!-- Mark which rating is selected by setting the class -->
      <div
        class="well"
        v-on:click="ratingFilter = 0"
        :class="{ selectedRating: ratingFilter === 0}"
      >
        <span class="amount">{{averageRating}}</span>
        Average Rating
      </div>

      <div
        class="well"
        v-on:click="ratingFilter = 1"
        :class="{ selectedRating: ratingFilter === 1}"
      >
        <span class="amount">{{numberOfOneStarRatings}}</span>
        1 Star Review
      </div>

      <div
        class="well"
        v-on:click="ratingFilter = 2"
        :class="{ selectedRating: ratingFilter === 2}"
      >
        <span class="amount">{{numberOfTwoStarRatings}}</span>
        2 Star Review
      </div>

      <div
        class="well"
        v-on:click="ratingFilter = 3"
        :class="{ selectedRating: ratingFilter === 3}"
      >
        <span class="amount">{{numberOfThreeStarRatings}}</span>
        3 Star Review
      </div>

      <div
        class="well"
        v-on:click="ratingFilter = 4"
        :class="{ selectedRating: ratingFilter === 4}"
      >
        <span class="amount">{{numberOfFourStarRatings}}</span>
        4 Star Review
      </div>

      <div
        class="well"
        v-on:click="ratingFilter = 5"
        :class="{ selectedRating: ratingFilter === 5}"
      >
        <span class="amount">{{numberOfFiveStarRatings}}</span>
        5 Star Review
      </div>
    </div>
    <!-- Add a link to show or hide the form -->
    <a href="#" v-on:click.prevent="showForm=true" v-show="!showForm">Add a Review</a>
    <!-- The form that allows the user to add a new review -->
    <!-- Only show the form of the showForm variable is set -->
    <form v-on:submit.prevent="addNewReview" v-show="showForm">
      <div class="form-element">
        <label for="reviewer">Name:</label>
        <input id="reviewer" type="text" required v-model="newReview.reviewer" />
      </div>
      <div class="form-element">
        <label for="title">Title:</label>
        <input id="title" type="text" required v-model="newReview.title" />
      </div>
      <div class="form-element">
        <label for="rating">Rating:</label>
        <input id="rating" type="number" min="1" max="5" required v-model.number="newReview.rating" />
      </div>
      <div class="form-element">
        <label for="review">Review:</label>
        <textarea id="review" required v-model="newReview.review" />
      </div>
      <input type="submit" value="Save" />
      <input type="button" value="Cancel" @click="resetForm" />
    </form>

    <!-- Display each review in a loop -->
    <!-- Display the filteredReviews array instead of the raw data -->
    <div
      v-bind:class="{ 'review': true, 'fab': review.favorite }"
      v-for="review in filteredReviews"
      v-bind:key="review.id"
    >
      <h4>{{review.reviewer}}</h4>
      <div class="rating">
        <img src="../assets/star.png" class="ratingStar" v-for="i in review.rating" v-bind:key="i" />
      </div>
      <h3>{{review.title}}</h3>
      <p>{{review.review}}</p>
      <p>
        Favorite?
        <input type="checkbox" v-model="review.favorite" />
      </p>
    </div>
  </div>
</template>

<script>
/*****************************************************************************************
******************************************************************************************
  TODO 01: Add vuex to this project
    >>vue add vuex

  TODO 02: Move the shared data to Vuex state:
      title
      description
      reviews (temporarily leave an empty array here to everything does not blow up)
      ratingFilter

  TODO 03: Update the binding to title and description
          Update filteredReviews computed property to use the data in $store.state

  TODO 04: Create AverageSummary component
      Move the HTML from the Average Rating well
      Move the averageRating computed property
      Copy (for now) the div.well styles (and the .selectedRating style)
      import the component into ProductReview and display it

  TODO 05: Add a mutation for ratingFilter so that we can update it from the well displays
      Then add a method (updateFilter) to commit that mutation when the user clicks on the AverageRating display

  TODO 06: Create StarSummary component
      Move the HTML from the Star Rating well
      Copy (for now) the div.well styles (and the .selectedRating style)
      Add a data field for the "ratingValue" (hardcode it to 1 for now)
      Copy one of the numberofstarratings computed properties and update it to compare to ratingValue
      update the text in the div to not hardcode the rating value
      import the component into ProductReview and display it
      Then add a method (updateFilter) to commit that mutation when the user clicks on the StarRating display

  TODO 07: Change the ratingValue from data to a prop, so it can be passed in by the parent
        Generate 5 of these in a loop in the parent, and bind to the rating-value prop

  TODO 08: Create the AddReview component
      Move the Anchor and the Form into the template
      Move the newReview and showForm data into the component
      Move the addNewReview and resetForm methods
      Move styling for form fields
      Add the component to ProductReviews
      Add a mutation to the store for ADD_REVIEW
      commit the mutation in AddReview component, addNewReview method

  TODO 09: Create a ReviewList component
      Move the HTML for the list to the component
      Move the styling
      Move the filteredReviews computed property
      Bind to $store.state
      Add the component to ProductReviews

  TODO 10: Create the ReviewDisplay component (out of the ReviewList component)
      Move the HTML for each review
      Move all the styling
      Add a props for review : Object
      Add the component to ReviewList
      Add a mutation for Toggling favorite
      Call the mutation when the checkbox is clicked
      Bind checked attribute to review.favorite 
******************************************************************************************
*****************************************************************************************/

export default {
  name: "product-review",
  data() {
    return {
      title: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all your squirrelly friends",

      ratingFilter: 0, // A variable to hold the current ratings Filter value
      newReview: {}, // A new, empty review object for adding new reviews.
      showForm: false, // A variable to store whether the Add Review form should be visible

      reviews: [
        {
          id: 1,
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review:
            "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
          rating: 3,
          favorite: false,
        },
        {
          id: 2,
          reviewer: "Craig Castelaz",
          title: "Better than a swift kick in the butt!",
          review: "My bar is low.",
          rating: 4,
          favorite: false,
        },
        {
          id: 3,
          reviewer: "Ed",
          title: "Better than Cats",
          review: "I loved it.  It was great.  It was better than CAts.",
          rating: 2,
          favorite: false,
        },
        {
          id: 4,
          reviewer: "Lace",
          title: "It's no FizzBuzz",
          review:
            "Not the most constructive how-to. I think the author may be nuts.",
          rating: 2,
          favorite: false,
        },
        {
          id: 5,
          reviewer: "Joe",
          title: "Pick up the pace",
          review: "Like War and Peace, but much slower.",
          rating: 5,
          favorite: false,
        },
        {
          id: 6,
          reviewer: "Max",
          title: "Dummy",
          review: "The writer needs to read a 'writing for dummies' book.",
          rating: 1,
          favorite: false,
        },
      ],
    };
  },
  computed: {
    averageRating() {
      if (this.reviews.length === 0) {
        return 0;
      }

      let sum = this.reviews.reduce((accum, review) => {
        return accum + review.rating;
      }, 0);

      return (sum / this.reviews.length).toFixed(2);
    },
    numberOfOneStarRatings() {
      return this.numReviews(1);
    },
    numberOfTwoStarRatings() {
      return this.numReviews(2);
    },
    numberOfThreeStarRatings() {
      return this.numReviews(3);
    },
    numberOfFourStarRatings() {
      return this.numReviews(4);
    },
    numberOfFiveStarRatings() {
      return this.numReviews(5);
    },
    // A computed property filteredReviews to return the reviews to be displayed
    filteredReviews() {
      return this.reviews.filter(
        (r) => this.ratingFilter === 0 || r.rating === this.ratingFilter
      );
    },
  },
  methods: {
    numReviews(rating) {
      return this.reviews.filter((r) => r.rating === rating).length;
    },

    // Methods to add the new review or cancel the add
    addNewReview() {
      // Add the newReview object to the array.
      this.reviews.unshift(this.newReview);
      this.resetForm();
    },
    resetForm() {
      this.newReview = {};
      this.showForm = false;
    },
  },
};
</script>

<style scoped>
div.main {
  margin: 1rem 0;
}

div.main > img {
  border-radius: 50%;
  box-shadow: 5px 5px 5px orange;
}

div.main div.well-display {
  display: flex;
  justify-content: space-around;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  cursor: pointer;
}

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

div.main div.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}

div.main div.review div.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

div.main div.review div.rating img {
  height: 100%;
}

div.main div.review p {
  margin: 20px;
}

div.main div.review h3 {
  display: inline-block;
}

div.main div.review h4 {
  font-size: 1rem;
}

/* Mark which rating is selected */
.fab,
.selectedRating {
  background-color: lightyellow;
}

div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input,
div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type="button"] {
  width: 100px;
}
form > input[type="submit"] {
  width: 100px;
  margin-right: 10px;
}
</style>