<template>
  <div id="app" class="main">
    <!-- TODO: Add the router-view to display the current view -->
  </div>
</template>

<script>
/******************************************
 * Notes:
 *  1. There is a new ProductsList component, which simply lists all the products
 *      in $store in a table
 *  2. Vue Router has been added to this project. Note the files and folders that
 *      were added or modified.
 * 
 * 
 * Tasks
 *  1. Create a Products view which will be our home page (Products.vue)
 *      - Add a heading and the ProductsList component (ProductsList.vue)
 *      - Add it as the default route (/) (index.js)
 *      - Add the router-view (app.vue)
 * 2.  Create a ProductDetail view which displays a detailed view of the product (basically
 *      our reviews page from previous days)
 *      - Create the page (ProductDetail.vue) [Snippets.txt]
 *      - Add a route so that this page can be addressed (dynamic routing) [/product/:id]
 *      - Create a data property to hold the current productId (default to 0)
 *      - Add the created() function to set the productId to the $route parameter
 *      - Update the computed property to get the product using the productId
 *      - Test the route using ids (maybe use a v-if for product?)
 * 3.  Add router-link(s) in the ProductsList component to each of the products in the list, 
 *        binding to the "to" attribute/prop
 * 4.  Add a router-link on ProductDetail.vue to go "back to Products list", the home page
 * 5.  Make Add Review available once a user is looking at the ProductDetail view
 *      - Add a view for AddReviewPage which hosts the AddReview component
 *      - Add a route for AddReviewPage. /product/:id/add-review
 *      - add a router-link to the ProductDetail view to go to the Add Review view.
 *      - Update AddReview to go back to the product page after the review has been added 
 *        (or canceled) 
 *    
 */
export default {
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  max-width: 800px;
  margin: 60px auto 0 auto;
}

.selectedFilter {
  background-color: lightyellow;
}
</style>
