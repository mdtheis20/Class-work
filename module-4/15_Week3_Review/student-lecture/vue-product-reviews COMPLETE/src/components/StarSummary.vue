<template>
  <!-- Set the filter when the user clicks on the display -->
  <!-- Mark which rating is selected by setting the class -->

  <div
    class="well"
    @click="updateFilter"
    :class="{ selectedRating: $store.state.ratingFilter === ratingValue}"
  >
    <span class="amount">{{numberReviews}}</span>
    {{ ratingValue }} Star Review
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  props: {
    ratingValue: Number,
  },
  computed: {
    numberReviews() {
      return this.$store.state.reviews.filter(
        (r) => r.rating === this.ratingValue
      ).length;
    },
  },
  methods: {
    updateFilter() {
      this.$store.commit("UPDATE_FILTER", this.ratingValue);
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