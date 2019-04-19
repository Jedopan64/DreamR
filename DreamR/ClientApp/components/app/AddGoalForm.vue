<template>
   <form @submit.prevent="submit" class="p-2">
    <b-alert variant="danger" :show="regErrors !== null" dismissible @dismissed="regErrors = null">
      <div v-for="(error, index) in regErrors" :key="index">{{ error[0] }}</div>
    </b-alert>
    <b-form-group label="Title">
      <b-form-input v-model.trim="title" />
    </b-form-group>
    <b-form-group label="Category">    
      <b-form-select v-model="category" class="mb-3"> />
          <option>Tent</option>>
          <option>Garage</option>
    </b-form-group>
    <b-form-group label="Password">
      <b-form-input v-model.trim="password" type="password" />
    </b-form-group>
    <b-form-group label="Confirm Password">
      <b-form-input v-model.trim="confirmPassword" 
      type="password" />
    </b-form-group>
    <b-form-group>
      <b-button variant="primary" type="submit"  
      :disabled="loading">Register</b-button>
      <b-button variant="default" @click="close" 
      :disabled="loading">Cancel</b-button>
    </b-form-group>
  </form>
</template>

<script>
export default {
  name: "add-goal-form",  
  props: {
    show: {
      type: Boolean,
      required: true
    }
  },
  data() {
    return {
      index: 0,
      registered: false
    };
  },
  methods: {
    success() {
      this.registered = true;
      this.index = 0;
    },
    close() {
      this.$store.commit("hideAuthModal");
      let query = Object.assign({}, this.$route.query);
      delete query.redirect;
      this.$router.push({ query: query });
    }
  }
};
</script>


