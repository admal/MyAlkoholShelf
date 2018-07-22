export interface IHttpService {
    makeRequest(url: string, data: any, method: string): Promise<Response>;
}