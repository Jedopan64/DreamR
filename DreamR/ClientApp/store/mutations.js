
export const initialise = (state, payload) => {
  Object.assign(state, payload);
};

export const showAuthModal = state => {
  state.showAuthModal = true;
};

export const hideAuthModal = state => {
  state.showAuthModal = false;
};

export const loginRequest = state => {
  state.loading = true;
};

export const loginSuccess = (state, payload) => {
  state.auth = payload;
  state.loading = false;
};

export const loginError = state => {
  state.loading = false;
};

export const registerRequest = state => {
  state.loading = true;
};

export const registerSuccess = state => {
  state.loading = false;
};

export const registerError = state => {
  state.loading = false;
};

export const logout = state => {
  state.auth = null;
};

export const showAddGoalForm= state => {
  state.showAddGoalForm = true;
};

export const hideAddGoalForm = state => {
  state.showAddGoalForm = false;
};

export const addGoalRequest = state =>{
  state.loading = true;
};
export const addGoalSuccess = state =>{
  state.loading = false;
};
export const addGoalError = state =>{
  state.loading=false;
};
/*
export const addGoalToList = (state, goal) => {
  state.goalList.push(goal);
};
*/

