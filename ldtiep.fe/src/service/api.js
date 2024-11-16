import axios from 'axios';

class API {
    constructor(controller) {
        this.baseUrl = `https://localhost:44356/api/v1/${controller}`;
        this.axiosInstance = axios.create({
            baseURL: this.baseUrl,
            // Add any default headers or interceptors here
        });
    }

    async paging(param) {
        return await this.get("/paging", param);
    }
    async add(body) {
        return await this.post("", body);
    }
    async byID(id) {
        return await this.get(`/${id}`);
    }
    async updateByID(id, data) {
        return await this.put(`/${id}`, data);
    }
    async get(endpoint, params) {
        try {
            const response = await this.axiosInstance.get(endpoint, { params });
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
    }
    async put(endpoint, data) {
        try {
            const response = await this.axiosInstance.put(endpoint, data);
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
    }
    async post(endpoint, data) {
        try {
            const response = await this.axiosInstance.post(endpoint, data);
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
    }
    showErrorToast() {
        console.log("Error")
    }
}

export default API;