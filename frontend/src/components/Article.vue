<template>
  <b-container class="my-3">
    <b-card-group deck>
      <b-card border-variant="dark" :header="article.name" align="center">
        <b-card-body>
          <b-img :src="article.image_url" fluid alt=""/>
          <div class="float-left">
            <b-button class="mb-2"><i class="fas fa-chevron-up"></i></b-button>
            <br/>
            <b-button><i class="fas fa-chevron-down"></i></b-button>
          </div>
        </b-card-body>
      </b-card>
    </b-card-group>
  </b-container>
</template>

<script>
  export default {
    name: 'Article',
    props: {
      article: Object,
    }
  }
</script>

<style scoped>

</style>