<template>
 <b-modal v-model="show" hide-header hide-footer no-close-on-backdrop no-close-on-esc>
   <form @submit.prevent="submit" class="p-2" enctype="multipart/form-data">
    <b-alert variant="danger" :show="regErrors !== null" dismissible @dismissed="regErrors = null">
      <div v-for="(error, index) in regErrors" :key="index">{{ error[0] }}</div>
    </b-alert>
    <b-alert variant="success" :show="added && 
    regErrors === null">
      Goal added successfuly.
    </b-alert>
    <b-form-group label="Title">
      <b-form-input v-model.trim="title" />
    </b-form-group>   
    <b-form-group label="Category">
      <b-form-select v-model.trim="category">
        <option>Travel</option>
        <option>Food</option>
        <option>Sport</option>
        <option>Home</option>     
      </b-form-select>
    </b-form-group> 
    <b-form-group label="Dead Line">
      <date-picker v-model="deadLine" lang="eng" type="date" format="DD/MM/YYYY"></date-picker>
    </b-form-group> 
    <b-form-group label="Description">
      <b-form-textarea v-model.trim="description" rows=3></b-form-textarea>
    </b-form-group>    
    <b-form-group label="Add picture">
      <b-form-file v-model="goalImageFile" id="goalImageFile" name="goalImageFile" type="file" accept="image/image/x-png,image/png,image/jpeg,image/jpg" @change="onFilePicked"></b-form-file>
    </b-form-group>
    <b-form-group>
      <b-img :src="goalImageURL" height="150" width="150"></b-img>
    </b-form-group>
    <b-form-group>
      <b-form-checkbox v-model="isCompleted" type="checkbox">Completed</b-form-checkbox>
    </b-form-group>   
    <b-form-group>   
      <b-form-checkbox v-model="isPrivate" type="checkbox">Private</b-form-checkbox>
    </b-form-group>          
    <b-form-group>      
      <b-button variant="primary" type="submit"  
      :disabled="loading">Add</b-button>      
      <b-button variant="default" @click="close" 
      :disabled="loading">Cancel</b-button>
    </b-form-group>
  </form>
 </b-modal>
</template>


<script>
import DatePicker from 'vue2-datepicker'

export default {  
  name: "add-goal-form",  
  components: {
    DatePicker
  },
  props: {
    show: {
      type: Boolean,
      required: true
    }
  },
  data() {
    return {
      title:"",
      category:"",
      deadLine: "",
      description: "",
      isCompleted: false,
      isPrivate: false,
      goalImageURL: "",
      goalImageBinary: null,
      goalImageFile: null,          
      regErrors: null,  
      added: false              
    };
  },   
  methods: {     
      submit() {                  
        const payload = {
        title: this.title,
        category: this.category,
        deadLine: this.deadLine,
        description: this.description,
        goalImageBinary: this.goalImageBinary, 
        goalImageURL: this.goalImageURL,            
        isCompleted: this.isCompleted,
        isPrivate: this.isPrivate
      };

      this.$store
        .dispatch("addGoal", payload)
        .then(response => {
          this.regErrors = null;
          this.title= "",
          this.category= "";
          this.deadLine = "";
          this.description="";
          this.goalImageBinary=null;
          this.goalImageURL="";                           
          this.isPrivate= false;
          this.isCompleted=false;
          this.success();
        })
        .catch(error => {
          if (typeof error.data === "string" || error.data instanceof String) {
            this.regErrors = { error: [error.data] };
          } else {
            this.regErrors = error.data;
          }
        });         
    },   
    onFilePicked (event) {           
        const files = event.target.files
       
        let filename = files[0].name             
        
        if (filename.lastIndexOf('.') <= 0) {
          return alert('Please add a valid file!')
        }
        if (filename.lastIndexOf('png') <= 0 && filename.lastIndexOf('jpeg')<=0 && filename.lastIndexOf('jpg')<=0) {
          return alert('Please add a valid file!')
        }        
    
      
        const fileReader = new FileReader()   
        const fileReader2 = new FileReader()            
        fileReader.addEventListener('load', () => {
          this.goalImageURL =fileReader.result
        })     
        fileReader2.addEventListener('load', () => {
            this.goalImageBinary =fileReader.result
        })  
        fileReader.readAsDataURL(files[0])   
        fileReader2.readAsBinaryString(files[0])        
        this.goalImageFile = files[0]
        
        
      }, 
    success(){
      this.added = true;
    },   
          
    close() {
      this.regErrors = null;      
      this.$store.commit("hideAddGoalForm");
      this.$emit("close");
      let query = Object.assign({}, this.$route.query);
      delete query.redirect;
      this.$router.push({ query: query });
    }
  }
};
</script>

<style>
textarea {
  resize: none;
}
</style>
