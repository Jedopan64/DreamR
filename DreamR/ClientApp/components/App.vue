<template>
  <div class="app">
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
      <b-navbar-brand to="/">DreamR</b-navbar-brand>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav class="ml-auto mr-4">          
          <auth-nav-item />
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    
    <transition name="fade" mode="out-in">
      <router-view />
    </transition>

    <auth-modal :show="showAuthModal" />    
    <add-goal-form :show="showAddGoalForm" />  
  </div>
</template>

<script>
import AuthModal from "./app/AuthModal.vue";
import AuthNavItem from "./app/AuthNavItem.vue";
import AddGoalForm from "./app/AddGoalForm.vue";

export default {
  name: "app",
  components: {    
    AuthModal,
    AuthNavItem,  
    AddGoalForm,    
  },
  computed: {
    showAuthModal() {
      return this.$store.state.showAuthModal;
    },
    showAddGoalForm() {
      return this.$store.state.showAddGoalForm;
    }  
  }
};
</script>

<style lang="scss">
html,
body {
  height: 100vh;
}

div.app,
div.page {
  height: 100% !important;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease-in-out;
}
.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>