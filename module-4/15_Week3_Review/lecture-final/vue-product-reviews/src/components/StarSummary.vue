<template>
  <div class="well" v-on:click="updateFilter" :class="{ selectedRating: $store.state.ratingFilter === numberOfStars}">
    <span class="amount">{{numberReviews}}</span>
    {{numberOfStars}} Star Review
  </div>
</template>

<script>
export default {
    props: {
        numberOfStars : Number
    },
    data(){
        return {

        }
    },
    computed:{
        numberReviews() {
            return this.$store.state.reviews.filter((r) => r.rating === this.numberOfStars).length;
        }
    },
    methods: {
    updateFilter(){
      this.$store.commit("UPDATE_FILTER", this.numberOfStars);
    }

    }
};
</script>

<style>
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
.selectedRating {
  background-color: lightyellow;
}
</style>