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

    async paging(body) {
        return await this.post("/paging", body);
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
    async genCode() {
        return await this.get(`/gen-code`);
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
    async genNewKey() {
        return await this.get(`/gen-new-key`);
    }
    async upFile(file) {
        const formData = new FormData();
        formData.append('file', file);

        return await this.post("/image", formData, {
            'Content-Type': 'multipart/form-data'
        });
    }

    async blobImage(id) {
        const response = await this.axiosInstance.get(`/${id}`, { responseType: 'blob' });
        const blob = response.data;
        return new File([blob], response.headers['content-name'], { type: blob.type });
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
    async post(endpoint, data, headers = null) {
        try {
            const response = await this.axiosInstance.post(endpoint, data, { headers });
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