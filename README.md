# IPAM

[![.NET Core Desktop](https://github.com/Blizzardo1/IPAM/actions/workflows/dotnet-desktop.yml/badge.svg)](https://github.com/Blizzardo1/IPAM/actions/workflows/dotnet-desktop.yml)

This project took a span of 2 days to write and sort of perfect. Although not entirely perfect, it can use some additional tweaks such as removing the IP UserControl altogether and replace it with a custom object that can be added to a panel for easier management. This is a concept and should not really utilize larger networks.

The only reason why I even created this project was I needed a system to visualize the partition of my home network as I didn't want to use Excel or Google Sheets to make changes. This way I have a way to vizualize it without needing to find products that take forever to deploy or use overcomplicated systems like NetBox or old software like PHP-IPAM.

## Building

Simply pull the Repo and build, the only dependency used is Newtonsoft.Json as I believe them to be the greatest of all time. Their documentation is simply the best over Microsoft's Json in my honest opinion.

## Contributions

You are more than welcome to fork this repo and make changes as you see fit and contribute to this project to make a better overall product. I eventually plan to implement an ASP.NET Blazor site with an API to streamline the process.


## Roadmap

### Router Plugin

I plan to add router controls to automagically pull from the leases and static pools. This would have to be a plugin system as there are a yes amount of brands out there. I would likely start with Ubiquiti Routers as they are familiar with me, yet the system should make it to where anyone can create router plugins to pull the necessary data

### Autoping

Pinging active nodes will give you a more robust overview of what's alive and not. Although I have another system for this, it doesn't hurt to have another. This idea would utilize the ICMP protocol. If necessary, a Wake-On-Lan feature could also be added.


### Risks

To minimize risks of the above proposed features, there would need to be proper timeouts set to ensure no denial of service attacks be present.
