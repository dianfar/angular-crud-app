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
    formLabel: string;
    isEditMode = false;
    form: FormGroup;
    product: IProduct = <IProduct>{};

    constructor(private appService: AppService, private formBuilder: FormBuilder) {
        this.form = formBuilder.group({
            "name": ["", Validators.required],
            "quantity": ["", [Validators.required, Validators.pattern("^[0-9]*$")]],
            "price": ["", [Validators.required, Validators.pattern("^[0-9]*$")]],
            "category": ["", Validators.required],
            "supplier": ["", Validators.required]
        });

        this.formLabel = "Add Product";
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
        this.product.name = this.form.controls['name'].value;
        this.product.quantity = this.form.controls['quantity'].value;
        this.product.price = this.form.controls['price'].value;
        this.product.supplierId = this.form.controls['supplier'].value;
        this.product.categoryId = this.form.controls['category'].value;
        if (this.isEditMode) {
            this.appService.editProduct(this.product).subscribe(response => {
                this.getProducts();
                this.form.reset();
            });
        } else {
            this.appService.addProduct(this.product).subscribe(response => {
                this.getProducts();
                this.form.reset();
            });
        }   
    }

    cancel() {
        this.formLabel = "Add Product";
        this.isEditMode = false;
        this.product = <IProduct>{};
        this.form.get("name").setValue('');
        this.form.get("quantity").setValue('');
        this.form.get('price').setValue('');
        this.form.get('supplier').setValue(0);
        this.form.get('category').setValue(0); 
    }

    edit(product: IProduct) {
        this.formLabel = "Edit Product";
        this.isEditMode = true;
        this.product = product;
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