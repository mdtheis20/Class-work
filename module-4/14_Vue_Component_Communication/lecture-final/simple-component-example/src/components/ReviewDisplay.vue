<template>
  <!-- ********************** HTML for ReviewDisplay template ********************** -->
  <div class="review">
    <h4>{{review.reviewer}}</h4>
    <div class="rating">
      <img src="../assets/star.png" class="ratingStar" v-for="i in review.rating" v-bind:key="i" />
    </div>
    <h3>{{review.title}}</h3>
    <p>{{review.review}}</p>
  </div>
  <!-- ********************** HTML for ReviewDisplay template ********************** -->
</template>

<script>
export default {
    props: {
        review: Object
    },
  data() {
    return {
    };
  },
};
</script>

<style>
/*************** Styles for ReviewDisplay **************************/
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
</style>