import { HttpClient, json } from "aurelia-fetch-client";
import { bindable, noView } from "aurelia-framework";

@noView()
export class DataSourceCustomElement {
    @bindable url: string;
    @bindable autoLoad: boolean = false;
    @bindable params: any = {};
    @bindable method: string = "POST";
    @bindable name: string;

    public data: any;
    public isLoaded: boolean = false;

    private _httpClient: HttpClient;

    bind(bindingContext: any) {
        this._httpClient = new HttpClient();

        if (this.autoLoad) {
            this.execute();
        }
    }

    public execute() {
        console.info("execute started");

        let requestData: HttpRequestData;
        if (this.method == "GET" || this.method == "get") {
            requestData = new GetHttpRequestData(this.url);
        } else {
            requestData = new PostHttpRequestData(this.url);
        }

        this._httpClient.fetch(this.url, requestData)
            .then(response => response.json())
            .then(data => this.data = data)
            .then(x => this.isLoaded = true);
    }
}

export abstract class HttpRequestData {
    method: string;
    params: any;
    url: string;
    headers:any;

    protected constructor(url: string) {
        this.url = url;
        this.headers = {
            'content-type': 'application/json'
        }
    }
}

export class GetHttpRequestData extends HttpRequestData {
    constructor(url: string) {
        super(url);
        this.method = "GET";
    }
}

export class PostHttpRequestData extends HttpRequestData {
    constructor(url: string, body?: any) {
        super(url);
        this.method = "POST";
        this.body = JSON.stringify(body);
    }

    public body: any;
}
