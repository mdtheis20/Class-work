<template>
  <div :class="{ 'review': true, 'fab': review.favorite }">
    <h4>{{review.reviewer}}</h4>
    <div class="rating">
      <img src="../assets/star.png" class="ratingStar" v-for="i in review.rating" v-bind:key="i" />
    </div>
    <h3>{{review.title}}</h3>
    <p>{{review.review}}</p>
    <p>
      Favorite?
      <input type="checkbox" :checked="review.favorite" @click="toggleFavorite(review)" />
    </p>
  </div>
</template>

<script>
export default {
    props: {
        review: Object
    },
    methods: {
        toggleFavorite(review){
            this.$store.commit('TOGGLE_FAVORITE', review);
        }
    },
};
</script>

<style>
div.review {
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}

div.review div.rating {
  height: 2rem;
  display: inline-block;
  vertical-align: top;
  margin: 0 0.5rem;
}

div.review div.rating img {
  height: 100%;
}

div.review p {
  margin: 20px;
}

div.review h3 {
  display: inline-block;
}

div.review h4 {
  font-size: 1rem;
}

/* Mark which rating is selected */
.fab {
  background-color: lightyellow;
}
</style>