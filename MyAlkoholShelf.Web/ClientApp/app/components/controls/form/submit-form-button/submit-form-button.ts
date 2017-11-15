import { HttpClient, json } from "aurelia-fetch-client";
import { bindable, inject } from "aurelia-framework";
import { HttpRequestData, GetHttpRequestData, PostHttpRequestData } from "../../http/datasource/data-source";

@inject(HttpClient)
export class SubmitFormButton {
    @bindable data: any;
    @bindable url: string;
    @bindable method: string = 'POST';
    @bindable text: string;
    private _httpClient: HttpClient;

    constructor(http: HttpClient) {
        this._httpClient = http;
    }

    bind(bindingContext: any) {
    }

    submit() {
        let requestData: HttpRequestData;
        if (this.method == "GET" || this.method == "get") {
            requestData = new GetHttpRequestData(this.url);
        } else {
            requestData = new PostHttpRequestData(this.url, this.data);
        }
        this._httpClient.fetch(this.url, requestData)
            .then(response => response.json())
            .then(data => console.log('reponse', data));
    }
}