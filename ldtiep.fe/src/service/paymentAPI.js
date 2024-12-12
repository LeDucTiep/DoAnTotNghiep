import axios from 'axios';
import { inject } from 'vue'

// {
//     "paymentContent": "Thanh toan dong hang ",
//     "paymentCurrency": "VND",
//     "paymentRefId": "ORGD2321",
//     "requiredAmount": 120000,
//     "paymentLanguage": "vn",
//     "merchantId": "MER0001",
//     "paymentDestinationId": "ZALOPAY",
//     "signature": "121432SDA"
//   }

class Pay {
    constructor() {
        this.vs = inject('$vs')
        this.baseUrl = `https://localhost:44356/api/v1/Products/gen-payment`;
        this.axiosInstance = axios.create({
            baseURL: this.baseUrl,
            // Add any default headers or interceptors here
        });
    }

    async getPayUrl(money) {
        const param = {
            "paymentContent": "Thanh toán đơn hàng tại YODY",
            "paymentCurrency": "VND",
            "paymentRefId": "ORGD" + Math.floor(Math.random() * 1000000) + 1,
            "requiredAmount": money || 120000,
            "paymentLanguage": "vn",
            "merchantId": `MER${Math.floor(Math.random() * 1000000) + 1}${Math.floor(Math.random() * 1000000) + 1}`,
            "paymentDestinationId": "ZALOPAY",
            "signature": "SDA" + Math.floor(Math.random() * 1000000) + 1
        };
        return await this.post('', param);
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

export default Pay;