<template>
  <b-container class="my-3" @click.stop="goToArticle">
    <b-card-group deck>
      <b-card border-variant="dark" :header="article.name" align="center">
        <b-card-body>
          <b-img ref="imgArticle" :src="'https://localhost:44342' + article.path" fluid alt="" @load="calcMarginButton" style="max-width: 80%;"/>
          <div class="float-left" ref="buttonArticle" :style="{marginTop: marginImgArticle + 'px'}">
            <div class="col">
              <div class="row">
                <b-button @click.stop="actualVote=1" :style="{color: actualVote===1 ? '#25DD25' : 'white'}"><i class="fas fa-thumbs-up"></i></b-button>
              </div>
              <div class="row justify-content-md-center my-2" :style="{color: voteColor}">
                  {{article.points}}
              </div>
              <div class="row">
                <b-button @click.stop="actualVote=-1"  :style="{color: actualVote===-1 ? '#FF0000' : 'white'}"><i class="fas fa-thumbs-down"></i></b-button>
              </div>
            </div>
          </div>
          <br>
          <b-button class="my-3" @click.stop="showComment= !showComment">{{showComment ? 'Hide comment' : 'Show comment'}}</b-button>
          <div v-show="showComment" class="row border border-secondary rounded px-2">
            <div class="col-12 my-1 py-2 text-left border border-secondary rounded">
              <b-form-textarea placeholder="Your comment..." v-model="newCommentContent"></b-form-textarea>
              <div class="text-right">
                <b-button class="mr-2 mt-2" variant="outline-primary" @click.stop="postComment">Post</b-button>
              </div>
            </div>
            <div class="col-12 my-1 text-left border border-secondary rounded" v-for="(c,i) in article.comments" :key="i">
              <small class="my-0">{{c.user}}</small>
              <p>{{c.comments}}</p>
            </div>
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
    },
    data () {
      return {
        marginImgArticle: 50,
        actualVote: 0,
        showComment: false,
        newCommentContent: "",
      }
    },
    mounted () {
      this.loaded = true
    },
    methods: {
      calcMarginButton() {
        this.marginImgArticle = this.$refs.imgArticle.height / 2 - this.$refs.buttonArticle.clientHeight / 2
      },
      postComment() {
        if(this.newCommentContent) {
          const fd = new FormData()
          fd.append('id',  this.article.id)
          fd.append('comment', this.newCommentContent)
          this.axios.post('https://localhost:44342/api/comment', fd).then(result => {
            if(result.data === "ok") {
             reloadActualPicture()
            }
            this.newCommentContent = ""
            })
        }
      },
      goToArticle() {
        this.$router.push({name: 'post-id', params: {id: this.article.id}})
      },
      reloadActualPicture() {
        this.axios.get(`https://localhost:44342/api/image/${this.article.id}`).then(result => {
          let article = result.data
          if(article.text !== null) {
            this.article=result.data
          }
        })
      }
    },
    computed: {
      voteColor() {
        if(this.article.points < 0) {
          return '#FF0000'
        } if(this.article.points > 0) {
         return '#25DD25'
        }
        return '#000'
      },
    },
    watch: {	
      actualVote(newValue, oldValue) {
        const fd = new FormData()
        fd.append('id',  this.article.id)
        fd.append('point', newValue)
        this.axios.post("https://localhost:44342/api/vote", fd).then(result => {
          if(result.data==="ok") {
            this.reloadActualPicture()
          }
        })
      },	
    }
  }
</script>

<style scoped>

</style>