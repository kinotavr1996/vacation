import { ApiServers } from "./api-servers.enum";

export class ApiBaseUrl {
    static get(env:any): string {
        switch (env) {
            case ApiServers.dev: {
                return "/api/";
            }
        }
    }
}
