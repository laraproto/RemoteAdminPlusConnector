[![Athena Award Badge](https://img.shields.io/endpoint?url=https%3A%2F%2Faward.athena.hackclub.com%2Fapi%2Fbadge)](https://award.athena.hackclub.com?utm_source=readme)

# RemoteAdminPlusConnector

Final project for athena, very very much on the end of event, allows syncing with RemoteAdminPlus for bans and players

## Production

- Download a tagged release, it's a single dll file
- Install, wait for the plugin to fail to load, config will be generated
- Add api url in the form of `http(s)://(panel_location)/api/rpc/` final slash is **mandatory**
- Add api key from admin settings, currently the page for it says Placeholder as it will eventually be moved
- Restart server, plugin will work

## Contributing

You need to have scp secret laboratory dedicated server installed, and ReferencePath via csproj.user pointed to the SCPSL_Data\Managed folder or an SL_REFERENCES environment variable pointing to it

Afterwards, you can develop on it, that's literally the only requirement, no external deps (as of now)