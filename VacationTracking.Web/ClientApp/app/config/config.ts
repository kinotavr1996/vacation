import { ApiBaseUrl } from "./shared/api-base-url";
import { ApiRequestUrls } from "./shared/api-request-urls";
import { ApiServers } from "./shared/api-servers.enum";

export class AppConfig {
    static apiUrl = ApiBaseUrl.get(ApiServers.dev);
    static urls = ApiRequestUrls.urls;
    static projectName = "VacationApp";
}
