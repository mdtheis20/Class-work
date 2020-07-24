<template>
  <div>
    <!-- Add a link to show or hide the form -->
    <a href="#" v-on:click.prevent="showForm=true" v-show="!showForm">Add a Review</a>
    <!-- The form that allows the user to add a new review -->
    <!-- Only show the form of the showForm variable is set -->
    <form v-on:submit.prevent="addNewReview" v-show="showForm">
      <div class="form-element">
        <label for="reviewer">Name:</label>
        <input id="reviewer" type="text" required v-model="newReview.reviewer" />
      </div>
      <div class="form-element">
        <label for="title">Title:</label>
        <input id="title" type="text" required v-model="newReview.title" />
      </div>
      <div class="form-element">
        <label for="rating">Rating:</label>
        <input id="rating" type="number" min="1" max="5" required v-model.number="newReview.rating" />
      </div>
      <div class="form-element">
        <label for="review">Review:</label>
        <textarea id="review" required v-model="newReview.review" />
      </div>
      <input type="submit" value="Save" />
      <input type="button" value="Cancel" @click="resetForm" />
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newReview: {}, // A new, empty review object for adding new reviews.
      showForm: false, // A variable to store whether the Add Review form should be visible
    };
  },
  methods: {
    // Methods to add the new review or cancel the add
    addNewReview() {
      // Add the newReview object to the array.
      this.$store.commit("ADD_REVIEW", this.newReview);
      this.resetForm();
    },
    resetForm() {
      this.newReview = {};
      this.showForm = false;
    },
  },
};
</script>

<style scoped>
div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input,
div.form-element > select {
  height: 30px;
  width: 300px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type="button"] {
  width: 100px;
}
form > input[type="submit"] {
  width: 100px;
  margin-right: 10px;
}
</style>