<template>
  <div>
    <!-- TODO: Display title (h1) and description (p) -->
    <h1>{{card.title}}</h1>
    <p>{{card.description}}</p>

    <!-- TODO: Show an animation if loading, or the real page once loading is finished -->

    <!-- TODO: Add comments-list to the display (import the component)
                Pass the card.comments as a prop 
    -->

    <!-- TODO: Add a link to go back to the Board -->
  </div>
</template>

<script>
// TODO: Import BoardService.js to have access to our data functions
import dataService from '@/services/BoardService.js'

export default {
  name: "card-detail",
  props: {
    cardId: String,
    boardId: String
  },
  //  TODO: Create an empty card property in data (title, description, status, comments[])
  data() {
    return {
      card: {}
    }
  },
  // TODO: Add an isLoading property to the data to manage the loading animation

  // TODO: Hook into the created lifecycle event to call getCard in boardService 
  //        and populate the card

  created() {
      // Interrogate the route and find the card that matches boardId + cardId
      dataService.getCard(this.boardId, this.cardId).then( card => {
        this.card = card;
      });
  }

};
</script>
