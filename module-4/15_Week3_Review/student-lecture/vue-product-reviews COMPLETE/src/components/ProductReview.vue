<template>
  <div class="main">
    <img alt="Cigar party!" src="../assets/cigarparty.jpg" />
    <!-- Everything needs to be inside this root element -->
    <h2>Product Reviews for {{$store.state.title}}</h2>
    <p class="description">{{$store.state.description}}</p>

    <div class="well-display">
      <average-summary />
      <star-summary v-for="rating in 5" :key="rating" :rating-value="rating" />
      <bar-chart class="bar-chart" :chartData="chartData" />
    </div>

    <add-review />

    <review-list />
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
import AverageSummary from "./AverageSummary.vue";
import StarSummary from "./StarSummary.vue";
import AddReview from "./AddReview.vue";
import ReviewList from "./ReviewList.vue";
import BarChart from "./BarChart.vue";

export default {
  name: "product-review",
  components: {
    AverageSummary,
    StarSummary,
    AddReview,
    ReviewList,
    BarChart,
  },
  data() {
    return {};
  },
  computed: {
    filteredReviews() {
      return this.$store.state.reviews.filter(
        (r) =>
          this.$store.state.ratingFilter === 0 ||
          r.rating === this.$store.state.ratingFilter
      );
    },
    chartData() {
      let dict = {};
      
      for (let r of this.$store.state.reviews) {
        if (!dict[r.rating]) {
          dict[r.rating] = 1;
        } else {
          dict[r.rating] += 1;
        }
      }
      
      for (let i=1; i<=5; i++) {
        if (!dict[i]) dict[i] = 0;
      }

      let arr = []
      for (let k in dict) {
        arr.push({id: k, value: dict[k], label: k + ((k == 1) ? ' star' : ' stars')});
      }
      return arr;
    },
  },
  methods: {},
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
  align-items: flex-end;
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

.bar-chart {
  width: 300px;
  height: 85px;
  /* border: 1px solid black; */
  font-size: 0.7rem;
}

</style>