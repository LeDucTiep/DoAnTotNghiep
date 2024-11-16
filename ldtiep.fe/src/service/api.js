import axios from 'axios';
import { inject } from 'vue'

class API {
    constructor(controller) {
        this.vs = inject('$vs')
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
    async checkExisted(body) {
        return await this.post("/checkExisted", body);
    }
    async byID(id) {
        return await this.get(`/${id}`);
    }
    async updateByID(id, data) {
        return await this.put(`/${id}`, data);
    }
    async deleteByID(id) {
        return await this.delete(`/${id}`);
    }
    async deleteMany(ids) {
        return await this.delete(``, ids);
    }

    async get(endpoint, params) {
        try {
            const response = await this.axiosInstance.get(endpoint, { params });
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
        return {};
    }
    async delete(endpoint, data = null) {
        try {
            const response = await this.axiosInstance.delete(endpoint, { data });
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
        return {};
    }
    async put(endpoint, data) {
        try {
            const response = await this.axiosInstance.put(endpoint, data);
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
        return {};
    }
    async post(endpoint, data) {
        try {
            const response = await this.axiosInstance.post(endpoint, data);
            return response.data;
        } catch (error) {
            // Handle errors here
            this.showErrorToast();
        }
        return {};
    }
    showErrorToast() {
        this.vs.notify({ title: 'Có lỗi xảy ra', text: 'Vui lòng kiểm tra lại kết nối mạng của bạn', color: 'danger' });
    }
}

export default API;