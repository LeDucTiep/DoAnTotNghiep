import { inject } from 'vue'

class Cart {
    constructor() {
        this.vs = inject('$vs')
    }

    add(p) {
        try {
            localStorage.setItem("product-cart-storage", JSON.stringify(p));
            this.showSuccessToast();
        } catch (e) {
            this.showErrorToast();
        }
    }

    get() {
        let res = [];

        let temp = localStorage.getItem("product-cart-storage");

        if (temp) {
            res = JSON.parse(temp);
        }

        return res;
    }

    showErrorToast() {
        this.vs.notify({
            title: 'Có lỗi xảy ra',
            text: 'Thêm vào giỏ hàng thất bại',
            color: 'danger',
        });
    }

    showSuccessToast() {
        this.vs.notify({
            title: 'Thành công',
            text: 'Thêm vào giỏ hàng thành công',
            color: 'success',
        });
    }
}

export default Cart;