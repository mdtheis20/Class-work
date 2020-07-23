<template>
  <div id="app">
    <product-review-page />
  </div>
</template>

<script>
import ProductReviewPage from './components/ProductReviewPage.vue'

export default {
  name: 'App',
  components: {
    ProductReviewPage
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
  
    /* Keep the reviews narrow */
  max-width: 800px;
  margin: 60px auto 0 auto;
}
</style>
