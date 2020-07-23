<template>
  <div class="main">
    <!-- Everything needs to be inside this root element -->
    <h2>Product Reviews for {{title}}</h2>
    <p class="description">{{description}}</p>

    <review-summary :reviewsInChild="reviews" />

    <review-display v-for="r in reviews" v-bind:key="r.id" v-bind:review="r" />
  </div>
</template>

<script>
/*************************************************
  TODO 01: Create a component for review-display
    Paste the template HTML
    Add an empty review to data
    Add the component to ProductReviewPage and see a review displayed
    Change the data in ReviewDisplay to props (review: Object)
    Add a loop to ProductReviewPage to display all reviews

  TODO 02: Create the ReviewSummary component
    Copy the HTML into the template
    Copy the styles into the style tags
    Create a props for reviews (Array)
    Add the component to ProductReviewPage, passing in the reviews for props
 */
import ReviewDisplay from "./ReviewDisplay.vue";
import ReviewSummary from "./ReviewSummary.vue";

export default {
  components: {
    ReviewDisplay,
    ReviewSummary
  },
  data() {
    return {
      title: "Cigar Parties for Dummies",
      description:
        "Host and plan the perfect cigar party for all your squirrelly friends",
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
};
</script>

<style scoped>
div.main {
  margin: 1rem 0;
}
</style>