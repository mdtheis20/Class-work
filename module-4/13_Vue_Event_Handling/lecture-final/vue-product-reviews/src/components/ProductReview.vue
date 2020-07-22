<template>
  <div class="main">
    <!-- Everything needs to be inside this root element -->
    <h2>Product Reviews for {{title}}</h2>
    <p class="description">{{description}}</p>

    <!-- TODO 02: Set the filter when the user clicks on the display -->
    <!-- TODO 05: Mark which rating is selected -->
    <div class="well-display">
      <div class="well" v-on:click="ratingFilter = 0" :class="{ selectedRating: ratingFilter === 0}">
        <span class="amount">{{averageRating}}</span>
        Average Rating
      </div>

      <div class="well" v-on:click="ratingFilter = 1" :class="{ selectedRating: ratingFilter === 1}">
        <span class="amount">{{numberOfOneStarRatings}}</span>
        1 Star Review
      </div>

      <div class="well" v-on:click="ratingFilter = 2" :class="{ selectedRating: ratingFilter === 2}">
        <span class="amount">{{numberOfTwoStarRatings}}</span>
        2 Star Review
      </div>

      <div class="well" v-on:click="ratingFilter = 3" :class="{ selectedRating: ratingFilter === 3}">
        <span class="amount">{{numberOfThreeStarRatings}}</span>
        3 Star Review
      </div>

      <div class="well" v-on:click="ratingFilter = 4" :class="{ selectedRating: ratingFilter === 4}">
        <span class="amount">{{numberOfFourStarRatings}}</span>
        4 Star Review
      </div>

      <div class="well" v-on:click="ratingFilter = 5" :class="{ selectedRating: ratingFilter === 5}">
        <span class="amount">{{numberOfFiveStarRatings}}</span>
        5 Star Review
      </div>
    </div>
    <!-- TODO 04: Add a link to show or hide the form -->
    <a href="#" v-on:click.prevent="showForm=true" v-show="!showForm" >Add a Review</a>
    <!-- TODO 03: Create the form that allows the user to add a new review -->
    <form v-on:submit.prevent="addNewReview" v-show="showForm">
      <div class="form-element">
        <label for="reviewer">Name: </label>
        <input id="reviewer" type="text" required v-model="newReview.reviewer" />
      </div>
      <div class="form-element">
        <label for="title">Title: </label>
        <input id="title" type="text" required v-model="newReview.title"/>
      </div>
      <div class="form-element">
        <label for="rating">Rating: </label>
        <input id="rating" type="number" min="1" max="5" required  v-model.number="newReview.rating"/>
      </div>
      <div class="form-element">
        <label for="review">Review: </label>
        <textarea id="review" required v-model="newReview.review"/>
      </div>
      <input type="submit" value="Save" />
      <input type="button" value="Cancel" @click="resetForm"/>
    </form>

    <!-- TODO 04: Only show the form of the showForm variable is set -->

    <!-- Display each review in a loop -->
    <!-- TODO 02: Display the filteredReviews array instead of the raw data -->
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
export default {
  name: "product-review",
  data() {
    return {
      title: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all your squirrelly friends",

      // TODO 02: Create a variable to hold the current ratings Filter value
      ratingFilter: 0,

      // TODO 03: Create a new, empty review object for adding new reviews.
      newReview: {},

      // TODO 04: Create a variable to store whether the Add Review form should be visible
      showForm: false,

      reviews: [
        {
          id: 1,
          reviewer: "Malcolm Gladwell",
          title: "What a book!",
          review:
            "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language.",
          rating: 3,
          favorite: false
        },
        {
          id: 2,
          reviewer: "Craig Castelaz",
          title: "Better than a swift kick in the butt!",
          review: "My bar is low.",
          rating: 4,
          favorite: false
        },
        {
          id: 3,
          reviewer: "Ed",
          title: "Better than Cats",
          review: "I loved it.  It was great.  It was better than CAts.",
          rating: 2,
          favorite: false
        },
        {
          id: 4,
          reviewer: "Lace",
          title: "It's no FizzBuzz",
          review:
            "Not the most constructive how-to. I think the author may be nuts.",
          rating: 2,
          favorite: false
        },
        {
          id: 5,
          reviewer: "Joe",
          title: "Pick up the pace",
          review: "Like War and Peace, but much slower.",
          rating: 5,
          favorite: false
        },
        {
          id: 6,
          reviewer: "Max",
          title: "Dummy",
          review: "The writer needs to read a 'writing for dummies' book.",
          rating: 1,
          favorite: false
        }
      ]
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
    // TODO 02: Add a computed property filteredReviews to return the reviews to be displayed
    filteredReviews(){
      return this.reviews.filter( r => this.ratingFilter === 0 || r.rating === this.ratingFilter )
    }
  },
  methods: {
    numReviews(rating) {
      return this.reviews.filter(r => r.rating === rating).length;
    },
    addNewReview(){
      // Add the newReview object to the array.
      this.reviews.unshift( this.newReview );
      this.resetForm();
      
    },
    resetForm() {
      this.newReview = {};
      this.showForm = false;
    }
  }
  // TODO 01: Create a method to determine the number of reviews given a rating, and call it from the computed properties

  // TODO 03: Create methods to add the new review or cancel the add
};
</script>

<style scoped>
div.main {
  margin: 1rem 0;
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

/* TODO 05: Mark which rating is selected */
.fab, .selectedRating {
  background-color: lightyellow;
}


div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input, div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type=button] {
  width: 100px;
}
form > input[type=submit] {
  width: 100px;
  margin-right: 10px;
}
</style>