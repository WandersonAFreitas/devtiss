import axios from "axios";

const api = axios.create({
    // baseURL: 'https://localhost:5001'
    baseURL: 'https://devtiss-backend.herokuapp.com/'
});

export default api;