<template>
  <div>
    <!-- Display each review in a loop -->
    <!-- Display the filteredReviews array instead of the raw data -->
    <review-display v-for="review in filteredReviews" :key="review.id" :review="review" />
  </div>
</template>

<script>
import ReviewDisplay from "./ReviewDisplay.vue";

export default {
  components: {
    ReviewDisplay,
  },
  computed: {
    filteredReviews() {
      return this.$store.state.reviews.filter(
        (r) =>
          this.$store.state.ratingFilter === 0 ||
          r.rating === this.$store.state.ratingFilter
      );
    },
  },
};
</script>

<style>
</style>