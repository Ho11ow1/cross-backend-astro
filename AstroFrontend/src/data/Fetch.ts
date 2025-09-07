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

export async function GetAllUsers() : Promise<User[] | null>
{
    const response = await fetch(`${GetApiEndpoint()}/users`, { method: "GET" });
    if (!response.ok)
    {
        throw new Error(`Error fetching data: ${response.statusText}`);
    }

    const data = await response.json();

    return data as User[] | null;
}

export async function GetUserById(id: number) : Promise<User | null>
{
    const response = await fetch(`${GetApiEndpoint()}/user/${id}`, { method: "GET" });
    if (!response.ok)
    {
        throw new Error(`Error fetching data: ${response.statusText}`);
    }

    const data = await response.json();

    return data as User | null;
}

export async function DeleteUserById(id: number) : Promise<boolean>
{
    const response = await fetch(`${GetApiEndpoint()}/users/${id}`, { method: "DELETE" });
    if (!response.ok)
    {
        throw new Error(`Error fetching data: ${response.statusText}`);
    }

    const data = await response.json();

    return data.success as boolean;
}