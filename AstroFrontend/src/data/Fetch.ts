import { GetApiEndpoint } from "./AstroDefs";

export async function GetHelloFor(name: string) : Promise<string>
{
    const response = await fetch(`${GetApiEndpoint()}/greet/${name}`);
    if (!response.ok)
    {
        throw new Error(`Error fetching data: ${response.statusText}`);
    }

    const data = await response.json();

    const message = data.message;

    return message;
}