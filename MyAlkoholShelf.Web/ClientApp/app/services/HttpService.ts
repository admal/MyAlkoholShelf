import { IHttpService } from "./IHttpService";
import { HttpRequestFactory } from "./HttpRequestFactory";
import { HttpClient } from "aurelia-fetch-client";

export class HttpService implements IHttpService {
    private httpClient: HttpClient;

    constructor() {
        this.httpClient = new HttpClient();
    }

    makeRequest(url: string, data: any, method: string): Promise<Response> {
        let requestData = HttpRequestFactory.createRequest(method);
        requestData.setUrl(url);
        requestData.setParams(data);

        return this.httpClient.fetch(requestData.url, requestData);

    }
}