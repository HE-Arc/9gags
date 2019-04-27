<template>
    <div>
        <b-modal id="modal-create" centered title="Post an image" ref="modale-create">
        <b-form-group id="input-group-1" label="Image title:" label-for="imageTitle">
            <b-form-input
            id="imageTitle"
            v-model="title"
            required
            placeholder="Enter image title"
            ></b-form-input>
        </b-form-group>
            <b-form-group id="input-group-2" label="Image file:" label-for="image">
            <b-form-file v-model="image" id="image" :state="Boolean(image)" placeholder="Choose a picture..." drop-placeholder="Drop picture here..." accept="image/png, image/jpeg"></b-form-file>
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
    data() {
        return {
            image: null,
            title: "",
        }
    },
    methods:{
        hideModal() {
            this.$refs['modale-create'].hide()
        },
        postPicture() {
            //POST
            this.axios.post('https://localhost:44342/api/image', {FileUploadAPI: this.image, title: this.title}).then(result => {
                console.log(result)
            })
            this.hideModal()
        }
    }
  }
</script>