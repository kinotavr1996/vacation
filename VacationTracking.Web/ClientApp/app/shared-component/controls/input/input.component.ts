import { ValidationPropertyModel } from './../../../model/validator-property.model';
import { Component, Input, forwardRef } from "@angular/core";
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from "@angular/forms";

export const CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR: any = {
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => CustomInputComponent),
    multi: true
};

@Component({
    selector: "custom-input",
    templateUrl: "./input.component.html",
    styleUrls: ["./input.component.less",
        "./input-shared/input-for-admin-add-popup.less",
        "./input-shared/input-for-login.less",
        "./input-shared/input-for-admin-details.less"],
    providers: [CUSTOM_INPUT_CONTROL_VALUE_ACCESSOR]
})
export class CustomInputComponent implements ControlValueAccessor {
    @Input() type: string;
    @Input() name: string;
    @Input() label: string;
    @Input() placeholder: string;
    @Input() page: string;
    @Input() validator: ValidationPropertyModel;
    @Input() disabled: boolean = false;

    // The internal data model
    private innerValue: any = "";

    // Placeholders for the callbacks which are later providesd
    // by the Control Value Accessor
    private onTouchedCallback: () => void = Function;
    private onChangeCallback: (_: any) => void = Function;

    // get accessor
    get value(): any {
        return this.innerValue;
    };

    // set accessor including call the onchange callback
    set value(v: any) {
        if (v !== this.innerValue) {
            this.innerValue = v;
            this.onChangeCallback(v);
        }
    }

    get placeholderValue() {
        return this.placeholder;
    }

    // Set touched on blur
    onBlur() {
        this.onTouchedCallback();
    }

    // From ControlValueAccessor interface
    writeValue(value: any) {
        if (value !== this.innerValue) {
            this.innerValue = value;
        }
    }

    // From ControlValueAccessor interface
    registerOnChange(fn: any) {
        this.onChangeCallback = fn;
    }

    // From ControlValueAccessor interface
    registerOnTouched(fn: any) {
        this.onTouchedCallback = fn;
    }
}
