import { defineConfig } from 'astro/config';
import dotenv from 'dotenv';

dotenv.config({ path: '../.env' });

export default defineConfig({
    output: 'server',
    vite: 
    {
        resolve: 
        {
            alias: 
            {
                '@components': '/src/components',
                '@data': '/src/data',
                '@pages': '/src/pages',
                '@styles': '/src/styles'
            }
        }
    },
    devOptions:
    {
        port: Number(process.env.ASTRO_PORT) || 3000,
        strictPort: true
    }
});
