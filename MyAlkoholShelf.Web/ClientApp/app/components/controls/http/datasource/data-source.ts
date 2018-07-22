import { HttpService} from "app/services/HttpService";
import { json } from "aurelia-fetch-client";
import { bindable, noView, inject } from "aurelia-framework";
import * as $ from "jquery";

@noView()
@inject(HttpService)
export class DataSourceCustomElement {
    @bindable url: string;
    @bindable autoLoad: boolean = false;
    @bindable params: any = {};
    @bindable method: string = "POST";
    @bindable name: string;

    public data: any;
    public isLoaded: boolean = false;

    constructor(private httpService: HttpService) {
        
    }


    attached() {

        if (this.autoLoad) {
            this.execute();
        }
    }

    public execute() {
        console.info("execute started");

        this.httpService.makeRequest(this.url, this.params, this.method)
            .then(response => response.json())
            .then(data => this.data = data)
            .then(x => this.isLoaded = true)
            .then(x => console.log("Data fetched", x));
    }
}






