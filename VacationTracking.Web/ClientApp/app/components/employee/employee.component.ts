import { Component, OnInit } from "@angular/core";

@Component({
    template: require("./employee.component.html"),
    styles: [require("./employee.component.css")]
})
export class EmployeeComponent implements OnInit {

    constructor() {
        console.log('employee');
    }

    ngOnInit() {
    }

}
