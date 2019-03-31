<template>
  <div id="app">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <Navbar />
    <Article v-for="a in articles" :key="a.id" :article="a"/>
  </div>
</template>

<script>
import Navbar from './components/Navbar'
import Article from './components/Article'

export default {
  name: 'app',
  components: {
    Navbar,
    Article,
  },
  data() {
    return {
      articles: []
    }
  },
  mounted () {
    this.getArticles()
  },
  methods : {
    getArticles() {
      //Request articles
      for (let i = 0; i < 10; i++) {
        this.articles.push({name: `Titre ${i}`, image_url: `https://placeimg.com/200/400/${i}`})
        this.articles.push({name: `Titre ${i}`, image_url: `https://placeimg.com/400/200/${i}`})
      }
    }
  }
}
</script>

<style>

</style>
