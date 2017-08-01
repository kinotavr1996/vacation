import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { CustomInputComponent } from "./input/input.component";
import { FormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        FormsModule
    ],
    declarations: [
        CustomInputComponent
    ],
    exports: [
        CustomInputComponent
    ],
    providers: [
    ],
    bootstrap: [
    ]
})


export class ControlsModule { }
