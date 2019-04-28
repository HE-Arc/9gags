<template>
  <div>
    <b-modal id="modal-create" centered title="Post an image" ref="modale-create">
      <b-form-group id="input-group-1" label="Image title:" label-for="imageTitle">
        <b-form-input
          id="imageTitle"
          v-model="title"
          required
          placeholder="Enter image title" :state="Boolean(title)"
        ></b-form-input>
      </b-form-group>
      <b-form-group id="input-group-2" label="Image file:" label-for="image">
        <b-form-file v-model="image" id="image" :state="Boolean(image)" placeholder="Choose a picture..."
                     drop-placeholder="Drop picture here..." accept="image/*"></b-form-file>
      </b-form-group>
      <div slot="modal-footer" class="w-100">
        <div class="float-right">
          <b-button variant="outline-danger" class="mr-2" size="md" @click="hideModal">Close</b-button>
          <b-button variant="outline-primary" size="md" @click="postPicture()">Publish</b-button>
        </div>
      </div>
    </b-modal>
  </div>
</template>

<script>
  export default {
    name: 'ModalCreate',
    data () {
      return {
        image: null,
        title: null,
      }
    },
    methods:{
        hideModal() {
            this.$refs['modale-create'].hide()
        },
        postPicture() {
            //POST
            const fd = new FormData()
            fd.append('file',  this.image)
            fd.append('title', this.title)
            this.axios.post('https://localhost:44342/api/image', fd).then(result => {
                if(result.data[0] === "ok") {
                    this.$router.push({name: 'post-id', params:{id: result.data[1]}})
                    this.$store.commit('utils/SETSHOULDREFRESHSINGLE', true)
                }
            })
            this.title = null
            this.image = null
            this.hideModal()
        }
    },
  }
</script>