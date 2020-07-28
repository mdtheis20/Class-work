<template>
  <div class="card">

    <!-- Please leave <img> commented out until directed to remove open and close comment tags in the README.
    <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
    -->
    
  </div>
</template>

<script>
export default {
    name: 'book-card',
    data(){
        return {
            books: [
  {
    title: "Kafka on the Shore",
    author: "Haruki Murakami",
    read: false,
    isbn: "9781400079278"
  },
  {
    title: "The Girl With All the Gifts",
    author: "M.R. Carey",
    read: true,
    isbn: "9780356500157"
  },
  {
    title: "The Old Man and the Sea",
    author: "Ernest Hemingway",
    read: true,
    isbn: "9780684830490"
  },
  {
    title: "Le Petit Prince",
    author: "Antoine de Saint-Exupéry",
    read: false,
    isbn: "9783125971400"
  }
]
        }
    }
}
</script>

<style>
.card {
    border: 2px solid black;
    border-radius: 10px;
    width: 250px;
    height: 550px;
    margin: 20px;
}

.card.read {
    background-color: lightgray;
}

.card .book-title {
    font-size: 1.5rem;
}

.card .book-author {
    font-size: 1rem;
}
</style>