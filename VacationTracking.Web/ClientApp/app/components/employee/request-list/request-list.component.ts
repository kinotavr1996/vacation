import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeModel } from './../../../model/employee.model';
import { EmployeeHttpService } from './../employee-shared/employee-http.service';
import { RequestListModel } from './../../../model/request-list.model';
import { Component, Input, OnInit } from "@angular/core";
import { PagerService } from "../../../shared-component/paginator/paginator.component";

@Component({
    template: require("./request-list.component.html"),
    styles: [require("./request-list.component.css")]
})
export class RequestListComponent implements OnInit {
    isAddVisible: boolean = false;
    isEditVisible: boolean = false;
    model: RequestListModel;
    editModel: EmployeeModel;
    pager: any = {};
    pagedItems: any[];
    private sub: any;
    private id: number;
    constructor(private _httpService: EmployeeHttpService, private pagerService: PagerService, private route: ActivatedRoute, private router: Router) { }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.id = +params["id"];
        });
        this._httpService.getRequests(this.id)
            .subscribe(res => {
                this.model = RequestListModel.fromJSON(JSON.parse(res._body));
                this._setPage(1);
            });
    }

    delete(id: number) {
        if (confirm("Are you shure ?")) {
            this._httpService.deleteRequest(id)
                .subscribe(res => { this.ngOnInit(); });
        }
    }
    add() {
        this.router.navigateByUrl("/employee/add/" + this.id);
    }
    approve(id: number) {
        if (confirm("Are you shure ?")) {
            this._httpService.approve(id)
                .subscribe(res => { this.ngOnInit(); });
        }
    }
    sort(columnName: string) {
        if (this.model.direction == "ASC") {
            this.model.direction = "DESC";
            this.model.column = columnName;
            this._httpService.getSortingRequest(this.id, this.model.column, this.model.direction, this.model.page)
                .subscribe(res => {
                    console.log(res);
                    this.model = RequestListModel.fromJSON(res);
                });
        }
        else {
            this.model.direction = "ASC";
            this._httpService.getSortingRequest(this.id, this.model.column, this.model.direction, this.model.page)
                .subscribe(res => {
                    console.log(res);
                    this.model = RequestListModel.fromJSON(res);
                });
        }
    }

    private _setPage(page: number) {
        if (page < 1 || page > this.model.totalPage) {
            return;
        }
        this.model.page = page;
        this.pager = this.pagerService.getPager(this.model.page, this.model.pageSize, this.model.totalPage);
        this._httpService.getSortingRequest(this.id, this.model.column, this.model.direction, this.model.page)
            .subscribe(res => {
                this.model = RequestListModel.fromJSON(res);
            });
    }
}
