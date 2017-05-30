import { Component, OnInit, OnDestroy } from "@angular/core";
import { IProduct } from "./Models/product.interface";
import { ICategory } from "./Models/category.interface";
import { ISupplier } from "./Models/supplier.interface";
import { AppService } from "./app.service";
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
    selector: 'my-app',
    template: require('./app.html')
})

export class AppComponent {
    products: IProduct[] = [];
    categories: ICategory[] = [];
    suppliers: ISupplier[] = [];

    isEditMode = false;
    form: FormGroup;

    constructor(private appService: AppService, private formBuilder: FormBuilder) {
        this.form = formBuilder.group({
            "name": ["", Validators.required],
            "quantity": ["", Validators.required],
            "price": ["", Validators.required],
            "category": ["", Validators.required],
            "supplier": ["", Validators.required]
        });
    }

    ngOnInit() {
        this.getProducts();

        this.appService.getCategories().subscribe(categories => {
            this.categories = categories;
        });

        this.appService.getSuppliers().subscribe(suppliers => {
            this.suppliers = suppliers;
        });
    }

    onSubmit() {
        var product: IProduct = <IProduct>{};
        product.name = this.form.controls['name'].value;
        product.quantity = this.form.controls['quantity'].value;
        product.price = this.form.controls['price'].value;
        product.supplierId = this.form.controls['supplier'].value;
        product.categoryId = this.form.controls['category'].value;
        if (this.isEditMode) {
            this.appService.editProduct(product).subscribe(response => {
                this.getProducts();
                this.form.reset();
            });
        } else {
            this.appService.addProduct(product).subscribe(response => {
                this.getProducts();
                this.form.reset();
            });
        }   
    }

    edit(product: IProduct) {
        this.form.get("name").setValue(product.name);
        this.form.get("quantity").setValue(product.quantity); 
        this.form.get('price').setValue(product.price); 
        this.form.get('supplier').setValue(product.supplierId); 
        this.form.get('category').setValue(product.categoryId); 
    }

    delete(product: IProduct) {
        if (confirm("Are you sure want to delete this?")) {
            this.appService.deleteProduct(product.productId).subscribe(response => {
                this.getProducts();
                this.form.reset();
            });
        }
    }

    private getProducts() {
        this.appService.getProducts().subscribe(products => {
            this.products = products;
        });
    }
}