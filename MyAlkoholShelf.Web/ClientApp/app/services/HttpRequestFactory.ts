import { HttpRequestData, GetHttpRequestData, PostHttpRequestData } from "./requests/HttpRequestData";

export class HttpRequestFactory {
    static createRequest(method: string): HttpRequestData {
        let requestData: HttpRequestData;

        if (method == "GET" || method == "get") {
            requestData = new GetHttpRequestData();
        } else {
            requestData = new PostHttpRequestData();
        }
        return requestData;
    }
}