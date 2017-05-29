import { Injectable } from "@angular/core";
import { Http, Response } from "@angular/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
import { IProduct } from "./Models/product.interface";
import { ICategory } from "./Models/category.interface";
import { ISupplier } from "./Models/supplier.interface";

@Injectable()
export class AppService {
    constructor(private http: Http) { }

    getProducts() {
        return this.http.get("api/product").map(data => <IProduct[]>data.json());
    }

    addProduct(product: IProduct) {
        return this.http.post("api/product", product);
    }

    editProduct(product: IProduct) {
        return this.http.put("api/product", product);
    }

    deleteProduct(productId: number) {
        return this.http.delete(`api/product/${productId}`);
    }

    getCategories() {
        return this.http.get("api/category").map(data => <ICategory[]>data.json());
    }

    getSuppliers() {
        return this.http.get("api/supplier").map(data => <ISupplier[]>data.json());
    }
}