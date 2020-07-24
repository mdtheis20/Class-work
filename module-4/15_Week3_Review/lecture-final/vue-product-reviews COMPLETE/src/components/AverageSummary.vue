<template>
  <!-- Set the filter when the user clicks on the display -->
  <!-- Mark which rating is selected by setting the class -->

  <div
    class="well"
    @click="updateFilter"
    :class="{ selectedRating: $store.state.ratingFilter === 0}"
  >
    <span class="amount">{{averageRating}}</span>
    Average Rating
  </div>
</template>

<script>
export default {
  computed: {
    averageRating() {
      if (this.$store.state.reviews.length === 0) {
        return 0;
      }

      let sum = this.$store.state.reviews.reduce((accum, review) => {
        return accum + review.rating;
      }, 0);

      return (sum / this.$store.state.reviews.length).toFixed(2);
    },
  },
  methods: {
    updateFilter() {
      this.$store.commit("UPDATE_FILTER", 0);
    },
  },
};
</script>

<style>
.selectedRating {
  background-color: lightyellow;
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
</style>