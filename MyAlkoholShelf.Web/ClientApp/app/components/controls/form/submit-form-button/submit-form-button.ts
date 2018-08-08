import { json } from "aurelia-fetch-client";
import { bindable, inject } from "aurelia-framework";
import { HttpService } from "app/services/HttpService";
//import { HttpRequestData, GetHttpRequestData, PostHttpRequestData } from "../../http/datasource/data-source";

@inject(HttpService)
export class SubmitFormButton {
    @bindable data: any;
    @bindable url: string;
    @bindable text: string;

    constructor(private httpService: HttpService) {

    }

    bind(bindingContext: any) {
    }

    submit() {
        console.log("URL", this.url);
        console.log("SUBMIT model", this.data);

        this.httpService.makeRequest(this.url, this.data, "POST")
            .then(response => console.log(response));
    }
}