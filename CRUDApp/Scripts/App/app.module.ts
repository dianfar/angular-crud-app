import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { AppService } from "./app.service";

@NgModule({
    imports: [
        BrowserModule, HttpModule, ReactiveFormsModule
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent],
    providers: [AppService]
})

export class AppModule { }