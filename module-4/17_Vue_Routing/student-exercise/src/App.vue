<template>
  <div id="app">
    <nav>
      <router-link :to="{name: 'home'}" >Home</router-link> &nbsp;|
      <router-link :to="{name: 'myBooks'}">My Books</router-link>
      </nav>
    <router-view />
  </div>
</template>

<script>

export default {
  name: 'app'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin: 60px;
}
/* this is extra step */
nav > a {             
  margin: 5px 10px;
  padding: 3px 8px;
  border: 1px solid darkblue;
  border-radius: 7px;
}
.router-link-active{
  border: 3px solid blue;
  background-color: lightblue;
}
</style>
