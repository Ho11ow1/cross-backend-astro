import { GetApiEndpoint } from "./AstroDefs";
import type { User } from "./Types.ts";

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

export async function GetUsers() : Promise<User[]>
{
    const response = await fetch(`${GetApiEndpoint()}/users`);
    if (!response.ok)
    {
        throw new Error(`Error fetching data: ${response.statusText}`);
    }

    const data = await response.json();

    return data as User[];
}