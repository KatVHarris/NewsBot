# NewsBOT
## Summary
NewsBot is a bot made with the Microsfot Bot Framework. It uses the Bing Speech to Text API, to read of headlines from RSS feed. 

## Build
To build simply hit run. The BTTS calls are in Message Controller.

## Contributors
* KatVHarris
* AJLange
* ShahedC

## Todos
* Segment out the calls into Dialogs
* Add audio output for mulitple channels

## Issues
#### Models
The Models are generated from the raw JSON after the Newtonsoft library converts RSS XML to JSON. The problem with this is that the feeds have different formats.

#### Audio 
When using the BTTS API audio will only play with the connector IDE that you are using has an audio player. 


