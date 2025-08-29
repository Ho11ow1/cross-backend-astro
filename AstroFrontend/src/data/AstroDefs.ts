const Backend: string = import.meta.env.ACTIVE_BACKEND.toLowerCase();
const BackendURL: string = DetermineBackendURL();
const ApiEndpoint = `${BackendURL}/api`

function DetermineBackendURL()
{
    if (Backend == "dotnet")
    {
        return import.meta.env.BACKEND_DOTNET_URL;
    }
    else if (Backend == "springboot")
    {
        return import.meta.env.BACKEND_SPRING_URL;
    }
    else
    {
        throw Error(`Incorrect ACTIVE_BACKEND found in .env: ${Backend}`);
    }
}

export function GetBackend() { return Backend; }
export function GetBackendURL() { return BackendURL; }
export function GetApiEndpoint() { return ApiEndpoint; }