eapi -reloadCache
eapi whoami -as Guest|convertfrom-json|select -expand SingletonAppUser|convertto-json|out-file ~/.eapi/EffortlessAPIAccount.json