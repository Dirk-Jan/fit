import { RouterPaths } from './router-paths';
import { RouterModulePaths } from './router-module-paths';

export const InternalEndpoints = {
    FitModule: `/${RouterModulePaths.FitModulePrefix}`,
    AuthModule: `/${RouterModulePaths.AuthModulePrefix}`,

    // App Module
    Unauthorized: `/${RouterPaths.Unauthorized}`,

    // Fit Module
    OefeningenOverzicht: `/${RouterModulePaths.FitModulePrefix}/${RouterPaths.OefeningenOverzicht}`,
    OefeningDetails: `/${RouterModulePaths.FitModulePrefix}/${RouterPaths.OefeningDetails}`,
    NieuweOefening: `/${RouterModulePaths.FitModulePrefix}/${RouterPaths.NieuweOefening}`
}